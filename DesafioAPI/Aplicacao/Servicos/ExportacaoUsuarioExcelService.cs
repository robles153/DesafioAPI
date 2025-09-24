using ClosedXML.Excel;
using DesafioAPI.Aplicacao.Usuarios.UsuarioViewModels;

namespace DesafioAPI.Aplicacao.Servicos
{
    public class ExportacaoUsuarioExcelService
    {
        public byte[] GerarExcel(List<UsuarioViewModel> usuarios)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Usuários");

            // Cabeçalhos 
            worksheet.Cell(1, 1).Value = "Nome";
            worksheet.Cell(1, 2).Value = "Sobrenome";
            worksheet.Cell(1, 3).Value = "Email";
            worksheet.Cell(1, 4).Value = "NomeUsuario";
            worksheet.Cell(1, 5).Value = "Pais";
            worksheet.Cell(1, 6).Value = "Genero";
            worksheet.Cell(1, 7).Value = "DataNascimento";
            worksheet.Cell(1, 8).Value = "Telefone";
            worksheet.Cell(1, 9).Value = "Celular";
            worksheet.Cell(1, 10).Value = "Nacionalidade";

            worksheet.Range("A1:J1").Style.Font.SetBold();

            // Dados 
            for (int i = 0; i < usuarios.Count; i++)
            {
                var u = usuarios[i];
                worksheet.Cell(i + 2, 1).Value = u.Nome;
                worksheet.Cell(i + 2, 2).Value = u.Sobrenome;
                worksheet.Cell(i + 2, 3).Value = u.Email;
                worksheet.Cell(i + 2, 4).Value = u.NomeUsuario;
                worksheet.Cell(i + 2, 5).Value = u.Pais;
                worksheet.Cell(i + 2, 6).Value = u.Genero;
                worksheet.Cell(i + 2, 7).Value = u.DataNascimento;
                worksheet.Cell(i + 2, 8).Value = u.Telefone;
                worksheet.Cell(i + 2, 9).Value = u.Celular;
                worksheet.Cell(i + 2, 10).Value = u.Nacionalidade;
            }

            // Ajustar largura das colunas
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
