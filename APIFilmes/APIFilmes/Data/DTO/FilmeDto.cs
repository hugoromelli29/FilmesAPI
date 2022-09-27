using System.ComponentModel.DataAnnotations;

namespace APIFilmes.Data.DTO
{
    public class FilmeDto
    {
        // O DTO não possui ID, para usuário não entrar com ID

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(100, ErrorMessage = "O campo gênero não deve ter mais de 30 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório")]
        public int Ano { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ser entre 1 e 600 minutos")]
        public int Duracao { get; set; }
    }

}
