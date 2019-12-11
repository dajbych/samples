using Dajbych.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dajbych.Pages {
    public class IndexModel : PageModel {

        private readonly ILogger<IndexModel> logger;
        private readonly IReliableStateManager stateManager;

        public IndexModel(ILogger<IndexModel> logger, IReliableStateManager stateManager) {
            this.logger = logger;
            this.stateManager = stateManager;
        }

        public async Task OnGet() {
            var collection = await stateManager.GetOrAddAsync<IReliableDictionary<int, Fruit>>("Fruits");
            using var tx = stateManager.CreateTransaction();
            var fruits = await collection.CreateEnumerableAsync(tx);
            using var enumerator = fruits.GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync(CancellationToken.None)) {
                Fruits.Add(enumerator.Current.Key, enumerator.Current.Value);
            }
        }

        public Dictionary<int, Fruit> Fruits { get; } = new Dictionary<int, Fruit>();

        public async Task<IActionResult> OnPostAsync(int id, string name) {
            var collection = await stateManager.GetOrAddAsync<IReliableDictionary<int, Fruit>>("Fruits");
            using var tx = stateManager.CreateTransaction();
            await collection.AddOrUpdateAsync(tx, id, new Fruit(name), (i, f) => new Fruit(name) );
            await tx.CommitAsync();
            return RedirectToPage("./Index");
        }

    }
}
