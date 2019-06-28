// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EchoBot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot1 : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            //IConfigurationRoot configuration = builder.Build();
            //KeyExtraction keyExtraction = new KeyExtraction();
            List<string> keys = await KeyExtraction.CallWebAPIAsync(turnContext.Activity.Text.Trim());
            var documentModels = await AzureSearch.searchAzureSqlIndexer(keys);


            //await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);
            await turnContext.SendActivityAsync(MessageFactory.Text(documentModels.Count != 0 ? documentModels[0].docLink : "We did not find any referenced document"), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and welcome!"), cancellationToken);
                }
            }
        }
    }
}
