using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.Enums;
using TrackingCompanies.Domain.Interfaces;

namespace TrackingCompanies.Infrastructure.Persistence.Data;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly AppDbContext _context;

    public DatabaseSeeder(AppDbContext context)
    {
        _context = context;
    }
    public async Task SeedAsync()
    {
        await SeedIndustrySectorsAsync();
        await SeedCompaniesAsync();
        await SeedIndexesAsync();
        await _context.SaveChangesAsync();
    }
    
    private async Task SeedIndustrySectorsAsync()
    {
        if (await _context.IndustrySectors.AnyAsync())
            return;

        var sectors = new[]
        {
            IndustrySector.CreateIndustrySector(1, "Food and Beverage", "Food and Beverage" ),
            IndustrySector.CreateIndustrySector(2, "Aviation", "Flight company"),
            IndustrySector.CreateIndustrySector(3, "Finance", "Finance"),
            IndustrySector.CreateIndustrySector(4, "Stock Exchange","Stock Exchange"),
            IndustrySector.CreateIndustrySector(5, "Construction", "Construction" ),
            IndustrySector.CreateIndustrySector(6, "Education", "Education"),
            IndustrySector.CreateIndustrySector(7, "Finance", "Finance"),
            IndustrySector.CreateIndustrySector(8, "Energy","Energy"),
            IndustrySector.CreateIndustrySector(9, "Pharmaceutical", "Pharmacy, Chemistry, Drugstore" ),
            IndustrySector.CreateIndustrySector(10, "Railway", "Train company"),
            IndustrySector.CreateIndustrySector(11, "Real State", "Real State"),
            IndustrySector.CreateIndustrySector(12, "Car Renting","Car renting"),
            IndustrySector.CreateIndustrySector(13, "Wood and Beverage", "Food and Beverage" ),
            IndustrySector.CreateIndustrySector(14, "Wood and Cellulose", "Wood and Cellulose"),
            IndustrySector.CreateIndustrySector(15, "Mining", "Mining"),
            IndustrySector.CreateIndustrySector(16, "Petroil","Petroil"),
            IndustrySector.CreateIndustrySector(17, "Road and Highway", "Road" ),
            IndustrySector.CreateIndustrySector(18, "Sanitation", "Sanitation"),
            IndustrySector.CreateIndustrySector(19, "Health care", "Health care"),
            IndustrySector.CreateIndustrySector(20, "Insurance","Insurance"),
            IndustrySector.CreateIndustrySector(21, "Animal health care", "Pet shop" ),
            IndustrySector.CreateIndustrySector(22, "Steel industry", "Steel mill"),
            IndustrySector.CreateIndustrySector(23, "Telecommunications", "Telecom"),
            IndustrySector.CreateIndustrySector(24, "Technology","Technology"),
            IndustrySector.CreateIndustrySector(25, "Retail", "Retail" ),
            IndustrySector.CreateIndustrySector(26, "Tourism", "Tourism"),
            IndustrySector.CreateIndustrySector(27, "Motor", "Motor" ) 
        };

        await _context.IndustrySectors.AddRangeAsync(sectors);
    }

    private async Task SeedCompaniesAsync()
    {
        if (await _context.Companies.AnyAsync())
            return;

        var companies = new[]
        {
            Company.CreateNew("Banco do Brasil", "BBAS3", 7),
            Company.CreateNew("Petrobrás", "PETR3", 16),
            Company.CreateNew("Itaú S.A", "ITSA3", 7),
            Company.CreateNew("Bradesco", "BBDC3", 7)
        };

        await _context.Companies.AddRangeAsync(companies);
    }

    private async Task SeedIndexesAsync()
    {
        if (await _context.IndexTypes.AnyAsync()) return;
         
        var indexes = new[]{
            IndexType.CreateIndex("Margem Líquida",
                "Lucro Líquido ÷ Receita Líquida. Indica quanto a empresa efetivamente transforma em lucro. "
                , 0m,
                IndexGroup.Profitability),
            IndexType.CreateIndex("Margem Operacional",
            "EBIT / Receita Líquida. Avalia a eficiência do negócio antes de impostos e juros."
            , 0m,
            IndexGroup.Profitability),
            IndexType.CreateIndex("ROE (Return on Equity)",
                "Lucro Líquido ÷ Patrimônio Líquido. Mede a rentabilidade do capital próprio dos acionistas."
                , 0m,
                IndexGroup.Profitability),
            IndexType.CreateIndex("ROA (Return on Assets)",
                "Lucro Líquido ÷ Ativos Totais. Mede a eficiência da empresa em gerar lucro com os ativos."
                , 0m,
                IndexGroup.Profitability),
            IndexType.CreateIndex("Giro do Ativo",
                "Receita Líquida ÷ Ativo Total. Mede se os ativos estão a ser usados de forma produtiva."
                , 0m,
                IndexGroup.Efficiency),
            IndexType.CreateIndex("Ciclo Financeiro",
                "(prazo médio de recebimento + prazo médio de estocagem – prazo médio de pagamento). Avalia a eficiência no capital de giro."
                , 0m,
                IndexGroup.Efficiency),
            IndexType.CreateIndex("EBITDA / Receita.",
                "Indica a geração de caixa operacional em relação às vendas."
                , 0m,
                IndexGroup.Efficiency),
            IndexType.CreateIndex("Dívida Líquida / EBITDA",
                "Quantos anos de geração operacional seriam necessários para pagar a dívida líquida."
                , 0m,
                IndexGroup.Debit),
            IndexType.CreateIndex("Dívida Bruta / Patrimônio Líquido (Alavancagem)",
                "Mostra a proporção da dívida em relação ao capital próprio."
                , 0m,
                IndexGroup.Debit),
            IndexType.CreateIndex("Cobertura de Juros",
                "EBIT ÷ Despesa Financeira. Mede a capacidade de pagar os encargos da dívida."
                , 0m,
                IndexGroup.Debit),
            
            IndexType.CreateIndex("P/L (Preço sobre Lucro)",
                "Preço da Ação ÷ Lucro por Ação. Indica quantos anos o investidor levaria para recuperar o investimento via lucros, mantendo-se constantes."
                , 0m,
                IndexGroup.MarketValue),
            IndexType.CreateIndex("P/VP (Preço sobre Valor Patrimonial)",
                "Preço da Ação ÷ Patrimônio Líquido por Ação. Mede se a ação está cara ou barata em relação ao valor contábil."
                , 0m,
                IndexGroup.MarketValue),
            IndexType.CreateIndex("Dividend Yield",
                "Dividendos ÷ Preço da Ação. Mostra a remuneração do acionista em dividendos."
                , 0m,
                IndexGroup.MarketValue),
            IndexType.CreateIndex("EV/EBITDA",
                "(Enterprise Value sobre EBITDA). Avalia o valor da empresa em relação à sua geração operacional de caixa."
                , 0m,
                IndexGroup.MarketValue),
            IndexType.CreateIndex("PEG Ratio",
                "(P/L ÷ Crescimento do Lucro). Ajusta o P/L pela taxa de crescimento esperada dos lucros."
                , 0m,
                IndexGroup.MarketValue),
        };
        await _context.IndexTypes.AddRangeAsync(indexes);
    }
}