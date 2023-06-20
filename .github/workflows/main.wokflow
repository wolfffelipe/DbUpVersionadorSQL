workflow "Executar arquivo após push na master" {
  on = "push"
  resolves = ["executar"]
}

action "executar" {
  uses = "C:\Users\Usuario\source\repos\DbUpVersionadorSQL\DbUpVersionadorSQL\bin\Release\DbUpVersionadorSQL.exe"
  secrets = ["GITHUB_TOKEN"]
}
