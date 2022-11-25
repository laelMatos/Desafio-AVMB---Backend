using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackEnvelope.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Envelope",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    idRepositorio = table.Column<int>(type: "int", nullable: false),
                    idUsuário = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    incluirHashTodasPaginas = table.Column<string>(type: "char(1)", nullable: false),
                    permitirDespachos = table.Column<string>(type: "char(1)", nullable: false),
                    usarOrdem = table.Column<string>(type: "char(1)", nullable: false),
                    hashSHA256 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hashSHA512 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mensagemObservadores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motivoCancelamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroPaginas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    dataEnvioAgendado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    horaEnvioAgendado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dataHoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    objetoContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusContrato = table.Column<byte>(type: "tinyint", nullable: true),
                    numContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricaoContratante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricaoContratado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Envelope = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelope", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Envelope");
        }
    }
}
