using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Peak.Models;
using Peak.Queries;

namespace Peak.Helper
{
    public static class SqlHelper
    {
        public static List<GetCategoryResult> GetOrderCount(Stp_Oms_LiveContext dbContext,
            string startDate, string endDate)
        {
            var res = new List<GetCategoryResult>();

            string sql = @$"SELECT
                OrderMethodName,
                Cast(A.createtimestamputc AS DATE)   [Date],
                sum(Orderamount) as sales,
                max(Orderamount) as max_Order,
                Count(ordernumbercode)               AS [OrderCount]
                FROM   (
                SELECT  OrderMethodName,
                orderamount,
                ordernumbercode,
                               --Stptimezoneconvertdatetime
                               Dateadd(hour, -5, so.createtimestamputc)
                                      AS
                               CreateTimeStampUtc
                        FROM   [dbo].[soporder] [so](nolock)
                               INNER JOIN [dbo].[sopordermethodreference] SM WITH (nolock)
                                       ON [so].[sopordermethodreferenceid] =
                                          SM.[sopordermethodreferenceid]
                               INNER JOIN [dbo].[sopsaleschannelreference] SC WITH (nolock)
                                       ON SM.[sopsaleschannelreferenceid] =
                                          SC.[sopsaleschannelreferenceid]
                        WHERE  so.createtimestamputc BETWEEN
                               Dateadd(hour, 5, '{startDate}')
                               AND
                               Dateadd(hour, 5, '{endDate}')
                               AND OrderMethodName IN('Web Orders','App iPhone','App Android','Web Mobile')
                         ) A
                GROUP  BY OrderMethodName,Cast(A.createtimestamputc AS DATE)
                ORDER  BY 2 ASC";

            res =  dbContext.GetCategoryResults.FromSqlRaw(sql).ToList();
            return res;
        }
        public static List<GetTopFiveProductsResult> GetTopFiveProduct(Stp_Oms_LiveContext dbContext,
            string startDate, string endDate)
        {
            var res1 = new List<GetTopFiveProductsResult>();
                        string sql1 = $@"SELECT CAST('{startDate}' AS DATE)[DATE],* from (
            SELECT OrderMethodName,OrderLineCode,[Quantity],ROW_NUMBER() OVER(PARTITION BY OrderMethodName
                   ORDER BY [Quantity] desc) as [Rank] FROM (
            SELECT 

            OrderMethodName,

                                   [Sol].OrderLineCode,[Sol].OrderLineName,SUM([sol].NetQuantity) as [Quantity]
                        
                    FROM   [dbo].[soporder] [so](nolock)
                                  INNER JOIN [dbo].[SopOrderLine] [sol](nolock)
                                              ON [so].SopOrderID = [sol].SopOrderID
                           INNER JOIN [dbo].[sopordermethodreference] SM WITH (nolock)
                                   ON [so].[sopordermethodreferenceid] =
                                      SM.[sopordermethodreferenceid]
                           INNER JOIN [dbo].[sopsaleschannelreference] SC WITH (nolock)
                                   ON SM.[sopsaleschannelreferenceid] =
                                      SC.[sopsaleschannelreferenceid]
                    WHERE  so.createtimestamputc BETWEEN
                           Dateadd(hour, 5, '{startDate}')
                           AND
                           Dateadd(hour, 5, '{endDate}')
                          AND so.SopOrderMethodReferenceID IN(5,8,9,10)
                                   AND [sol].NetQuantity >0
                       
                       
                                    GROUP BY OrderMethodName,[Sol].OrderLineCode,[Sol].OrderLineName ) A
                                 ) B WHERE  [Rank]<=5

                                 ORDER BY Quantity desc ";
            res1= dbContext.GetTopFiveProductsResult.FromSqlRaw(sql1).ToList();
            return res1;
        }
        

    }
}
