using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProducatoriLocali.Models;
using ProducatoriLocali.Repositories;

namespace ProducatoriLocali.Controllers
{

    public class apiProductController : ApiController
    {
        IProductRepository _productRepo = new ProductRepo();

        [HttpPost]
        [Route("api/apiproduct/addprod")]
        public HttpResponseMessage CreateProduct(Product product, string UserId)
        {
            ApiProductResponse response = _productRepo.CreateProduct(product, UserId);
            if(response == ApiProductResponse.ADDPRODUCT_SUCCESS)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
