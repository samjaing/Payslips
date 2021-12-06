echo Building Project...
dotnet build

if [ $? -eq 0 ]
then
	echo Running...
	dotnet run --project ./Payslips
fi
