<Query Kind="Expression" />

from eachRow in SpecialEvents
where eachRow.Active
select new
{
	Code = eachRow.EventCode,
	Description = eachRow.Description
}