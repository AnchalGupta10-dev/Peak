SELECT
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
               Dateadd(hour, -19 ,GetDate() )
               AND
               Dateadd(hour ,5, GetDate())
               AND OrderMethodName IN('Web Orders','App iPhone','App Android','Web Mobile')
         ) A
GROUP  BY OrderMethodName,Cast(A.createtimestamputc AS DATE)
ORDER  BY 2 ASC