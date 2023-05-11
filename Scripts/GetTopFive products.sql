SELECT CAST(GetDATE() AS DATE)[DATE],* from (
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
               Dateadd(hour, -19,GetDATE())
               AND
               Dateadd(hour, 5, GetDATE())
              AND so.SopOrderMethodReferenceID IN(5,8,9,10)
                       AND [sol].NetQuantity >0
                       
                       
                        GROUP BY OrderMethodName,[Sol].OrderLineCode,[Sol].OrderLineName ) A
                     ) B WHERE  [Rank]<=5

                     ORDER BY 2