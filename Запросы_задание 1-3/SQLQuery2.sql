SELECT Cages.id as N'� ���������',
	   Cage_date as N'����',
	   Cages.Summary as N'�����',
	   Entrys.Summary as N'����� �� �������� �� ���� �����'
	FROM
	Cages
	JOIN ENTRYS
	ON Cages.id = Source_id
	where 
	Type = N'R'
	AND
	DATEPART(MONTH, Cage_date) = 7
