using DesafioAPI.Aplicacao.DTOs;
using DesafioAPI.Aplicacao.Servicos;

namespace TestDesafio.Fakes
{
    public class FakeRandomUserService : RandomUserService
    {
        private readonly RandomUserDto _dto;
        public FakeRandomUserService(RandomUserDto dto) : base(null!, null!) { _dto = dto; }
        public override Task<RandomUserDto?> GetRandomUserAsync() => Task.FromResult<RandomUserDto?>(_dto);
    }
}
