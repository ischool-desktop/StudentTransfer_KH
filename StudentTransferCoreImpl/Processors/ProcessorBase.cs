using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentTransferAPI;
using FISCA.Data;
using System.Xml.Linq;

namespace StudentTransferCoreImpl.Processors
{
    class ProcessorBase : TransferProcessor
    {
        private static QueryHelper _query = null;
        protected static QueryHelper Query
        {
            get
            {
                if (_query == null)
                    _query = new QueryHelper();

                return _query;
            }
        }

        private static UpdateHelper _update;
        protected static UpdateHelper Update
        {
            get
            {
                if (_update == null)
                    _update = new UpdateHelper();

                return _update;
            }
        }

        public override string Title
        {
            get { throw new NotImplementedException(); }
        }

        public override XElement TransferOut()
        {
            throw new NotImplementedException();
        }

        public override void TransferIn(XElement data)
        {
            throw new NotImplementedException();
        }
    }
}
