USE TestSqlManyToMany;
GO
declare @catId int;
DECLARE @name NVARCHAR (MAX), @catName  NVARCHAR (MAX);
set @catName = '';
set @name = N'кофе';
declare product_cursor CURSOR for
select Category_Id from ProductCategories where Product_Id = (select Id from Products where Name = @name);
open product_cursor
fetch next from product_cursor into @catId
while @@FETCH_STATUS = 0
begin
	 
	set @catName = @catName  + (select Name from Categories where Id = @catId)+ '  '
	fetch next from product_cursor into @catId
	end;
print @name + '='+ @catName
close product_cursor
DEALLOCATE product_cursor