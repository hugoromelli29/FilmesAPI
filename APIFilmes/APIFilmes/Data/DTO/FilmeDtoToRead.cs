using System.ComponentModel.DataAnnotations;
using System;

namespace APIFilmes.Data.DTO
{
    public class FilmeDtoToRead
    {

        // O DTO possuirá ao final campo para determinar a hora da consulta

        [Key]
        [Required]
        public int id { get; set; }

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
        private DateTime horaConsulta;
        public string HoraConsulta
        {
            get
            {
                horaConsulta = DateTime.Now;
                return string.Format("Consulta em: {0:dd/MM/yyyy HH:mm}", horaConsulta);
            }
        }
    }

}
