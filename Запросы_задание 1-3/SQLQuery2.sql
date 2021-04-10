SELECT Cages.id as N'є документа',
	   Cage_date as N'дата',
	   Cages.Summary as N'сумма',
	   Entrys.Summary as N'сумма по проводке за июль мес€ц'
	FROM
	Cages
	JOIN ENTRYS
	ON Cages.id = Source_id
	where 
	Type = N'R'
	AND
	DATEPART(MONTH, Cage_date) = 7
