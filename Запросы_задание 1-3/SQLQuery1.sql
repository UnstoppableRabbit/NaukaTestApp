SELECT Source
      ,Summary
  FROM ENTRYS
  WHERE DATEPART(MONTH, month) = 7 
  AND
  Source IN (
  SELECT Source
  	from ENTRYS
	WHERE DATEPART(MONTH, month) = 7 
	 group by Source
	 having count(*)=1
  )
  