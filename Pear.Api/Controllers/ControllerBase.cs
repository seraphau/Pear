namespace Pear.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Pear.Entity;

    public class ControllerBase : ApiController
    {
        private PearEntities _pearEntities = null;

        protected PearEntities dbPear
        {
            get
            {
                if (this._pearEntities == null)
                {
                    this._pearEntities = new PearEntities();
                }

                return this._pearEntities;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._pearEntities.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}