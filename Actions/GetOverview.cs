using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddoSamples.DomainModel;
using AddoSamples.Extensions;
using AddoSamples.Http;
using AddoSamples.RequestModels;
using AddoSamples.ResponseModels;
using Newtonsoft.Json;

namespace AddoSamples.Actions
{
    public class GetOverview
    {
        readonly Context _context;

        public GetOverview(Context context)
        {
            _context = context;
        }

        public List<AddoOverviewItem> Execute()
        {
            const int pageSize = 10;
            var model = new GetSigningsModel
            {    
                Page = 1,
                PageSize = pageSize,
                CreatedOnFrom = new DateTime(2000, 1, 1).AddoDate(),
                CreatedOnTo = DateTime.Now.AddoDate(),
                OrderType = 1, // 0 - Ascending, 1 - Descending
            };

            var post = new Post();
            var url = $"{_context.BaseUrl}/GetSignings";
            var overview = new List<AddoOverviewItem>();
            while (true)
            {
                var addoRequest = new AddoRequestModel<GetSigningsModel>(_context.Token, model);
                var body = JsonConvert.SerializeObject(addoRequest);
                var result = post.Execute(url, body).Result;
                var raw = Encoding.UTF8.GetString(result);
                var response = JsonConvert.DeserializeObject<GetSigningsResponseModel>(raw);
                if (response == null || !response.Signings.Any())
                {
                    break;
                }

                overview.AddRange(response.Signings);
                model.Page++;
            }

            return overview;
        }
    }
}