This shows a reproduction of Akavache compilation to native AOT

Steps:

```
dotnet publish

cd \Akavache.AOT-Sample\bin\Release\net9.0\win-x64\publish
.\Akavache.AOT-Sample.exe
```

I get an error:

```
Unhandled exception. System.InvalidOperationException: There is not a valid operation queue
   at System.Reactive.Subjects.AsyncSubject`1.GetResult() + 0x129
   at Program.<<Main>$>d__0.MoveNext() + 0x144
--- End of stack trace from previous location ---
   at Program.<Main>(String[] args) + 0x24
```

csproj already marks akavache as no trim:

```xml
 <ItemGroup>
        <TrimmerRootAssembly Include="Akavache"/>
        <TrimmerRootAssembly Include="Akavache.Core"/>
        <TrimmerRootAssembly Include="Akavache.Sqlite3"/>
        <TrimmerRootAssembly Include="Splat"/>
        <!--        <TrimmerRootAssembly Include="Akavache.Mac"/>-->
        <!--        <TrimmerRootAssembly Include="Akavache.Deprecated"/>-->
        <!--        <TrimmerRootAssembly Include="Akavache.Mobile"/>-->
        <!--        <TrimmerRootAssembly Include="Akavache.Drawing"/>-->
    </ItemGroup>
```

It works just fine in debug mode
