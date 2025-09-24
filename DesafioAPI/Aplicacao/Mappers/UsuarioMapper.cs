using DesafioAPI.Aplicacao.DTOs;
using DesafioAPI.Dominio.Entidades.Usuario;
using DesafioAPI.Dominio.Enuns;

namespace DesafioAPI.Aplicacao.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario FromRandomUserDto(RandomUserDto dto)
        {
            return new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Name.First,
                Sobrenome = dto.Name.Last,
                Email = dto.Email,
                NomeUsuario = dto.Login.Username,
                Pais = dto.Location.Country,
                Genero = dto.Gender.ToLower() switch
                {
                    "male" => Genero.Masculino,
                    "female" => Genero.Feminino,
                    _ => Genero.Outro
                },
                DataNascimento = dto.Dob.Date,
                Telefone = dto.Phone,
                Celular = dto.Cell,
                FotoUrl = dto.Picture.Large,
                Nacionalidade = dto.Nat
            };
        }
    }
}