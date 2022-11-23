using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnvelope.Domain
{
    [Table("Usuarios")]
    public sealed class Usuario
    {
        public Usuario(string id, string codigo, string nome, string iniciais, string email, 
            string ativo, string contaVerificada, string? celular, string imgAssinatura, 
            string imgAssinaturaExt, string imgRubrica, string imgRubricaExt, string cpf, 
            DateTime dataNascimento, string receberLinkAssinatura, string receberNotifConclusao, 
            string receberNotifPendente, string receberNoticias, string exibeAvisoEnvelope, 
            string utilizaAutenticacao2FA, string imgAutenticacao2FA, string acessoAPI, string tokenAPI, 
            string? urlCallback, string ignorarPlanoAssin, string googleAccId, DateTime dataHoraCadastro, string imgFoto)
        {
            this.id = id;
            this.codigo = codigo;
            this.nome = nome;
            this.iniciais = iniciais;
            this.email = email;
            this.ativo = ativo;
            this.contaVerificada = contaVerificada;
            this.celular = celular;
            this.imgAssinatura = imgAssinatura;
            this.imgAssinaturaExt = imgAssinaturaExt;
            this.imgRubrica = imgRubrica;
            this.imgRubricaExt = imgRubricaExt;
            this.cpf = cpf;
            this.dataNascimento = dataNascimento;
            this.receberLinkAssinatura = receberLinkAssinatura;
            this.receberNotifConclusao = receberNotifConclusao;
            this.receberNotifPendente = receberNotifPendente;
            this.receberNoticias = receberNoticias;
            this.exibeAvisoEnvelope = exibeAvisoEnvelope;
            this.utilizaAutenticacao2FA = utilizaAutenticacao2FA;
            this.imgAutenticacao2FA = imgAutenticacao2FA;
            this.acessoAPI = acessoAPI;
            this.tokenAPI = tokenAPI;
            this.urlCallback = urlCallback;
            this.ignorarPlanoAssin = ignorarPlanoAssin;
            this.googleAccId = googleAccId;
            this.dataHoraCadastro = dataHoraCadastro;
            this.imgFoto = imgFoto;
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }
        [Required]
        public string codigo { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string iniciais { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string ativo { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string contaVerificada { get; set; }
        public string? celular { get; set; }
        public string imgAssinatura { get; set; }
        public string imgAssinaturaExt { get; set; }
        public string imgRubrica { get; set; }
        public string imgRubricaExt { get; set; }
        [MaxLength(11)]
        public string cpf { get; set; }
        [Column(TypeName = "date")]
        public DateTime dataNascimento { get; set; }
        [Column(TypeName = "char(1)")]
        public string receberLinkAssinatura { get; set; }
        [Column(TypeName = "char(1)")]
        public string receberNotifConclusao { get; set; }
        [Column(TypeName = "char(1)")]
        public string receberNotifPendente { get; set; }
        [Column(TypeName = "char(1)")]
        public string receberNoticias { get; set; }
        [Column(TypeName = "char(1)")]
        public string exibeAvisoEnvelope { get; set; }
        [Column(TypeName = "char(1)")]
        public string utilizaAutenticacao2FA { get; set; }
        public string imgAutenticacao2FA { get; set; }
        [Column(TypeName = "char(1)")]
        public string acessoAPI { get; set; }
        public string tokenAPI { get; set; }
        public string? urlCallback { get; set; }
        [Column(TypeName = "char(1)")]
        public string ignorarPlanoAssin { get; set; }
        public string googleAccId { get; set; }
        public DateTime dataHoraCadastro { get; set; }
        public string imgFoto { get; set; }
    }
}
