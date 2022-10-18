using eTickets.Data.Base;
using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService:IEntityBaseRepository<Actor>
    {
       // bunun amacı Actor tipine özel bir metot yazacaksam eğer buraya yazarım ama genel her yerde kullanacağım metotların hepsi
       // şu an IEntityBaseRepository içerisinde. Şu an Actor class'ına ait özel bir metot olmadığı için, burası boş.
    }
}
