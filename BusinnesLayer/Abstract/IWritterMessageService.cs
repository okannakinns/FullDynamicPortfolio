using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IWriterMessageService : IGenericService<WriterMessage>
    {
        List<WriterMessage> GetListSenderMessages(string p);
        List<WriterMessage> GetListReceiverMessages(string p);
    }
}
