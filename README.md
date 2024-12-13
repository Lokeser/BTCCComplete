# Sistema de Gerenciamento de TCC

Este projeto é um sistema de gerenciamento de Trabalhos de Conclusão de Curso (TCC), desenvolvido para auxiliar na organização e controle de alunos, professores, cursos e bancas. Ele é ideal para instituições acadêmicas que buscam uma solução prática e eficiente para estruturar suas atividades relacionadas ao TCC.

## Objetivo do Sistema

O sistema tem como objetivo principal facilitar o acompanhamento de todo o processo do TCC, desde a criação de cursos e a gestão de alunos e professores, até a definição de bancas e realização das apresentações. Com ele, é possível organizar:

- **Cursos:** Gerenciar os cursos disponíveis e seus respectivos professores.
- **Alunos:** Matricular alunos nos cursos e organizar seus trabalhos.
- **Professores:** Definir professores orientadores e os que lecionam em cursos.
- **Bancas:** Formar bancas avaliadoras com convidados opcionais.
- **Comentários:** Permitir que professores comentem em bancas para avaliações e feedback.

## Funcionalidades

1. **Gerenciamento de Cursos:**
   - Criar novos cursos.
   - Associar professores como responsáveis por lecionar os cursos.

2. **Cadastro de Alunos e Professores:**
   - Adicionar novos alunos e professores ao sistema.

3. **Definição de Orientadores:**
   - Organizar a lista de professores disponíveis para orientação.

4. **Criação de Trabalhos Acadêmicos:**
   - Registrar os trabalhos dos alunos e associá-los aos orientadores.

5. **Convidados para Bancas:**
   - Professores podem adicionar convidados externos para participar das bancas (opcional).

6. **Formação de Bancas:**
   - Configurar as bancas avaliadoras para apresentação dos TCCs.

7. **Interação nas Bancas:**
   - Professores podem comentar e avaliar os trabalhos apresentados nas bancas.

## Como Usar o Sistema

### 1. Criar um Curso
- Acesse a área de gerenciamento de cursos "/Cursos".
- Clique em "Novo".
- Preencha os detalhes do curso, como nome, área e carga horária.
- Associe professores que irão lecionar o curso.

### 2. Criar Autores e Professores
- Vá para as seções "/Autores" e "/Professores".
- Clique em "Novo" e preencha os dados necessários, como nome, matrícula e e-mail.

### 3. Criar a Ordem de Orientadores
- Na página de gerenciamento de ordem em "/Orientador", defina quais estão disponíveis para orientação.
- Organize a ordem de prioridade caso necessário.

### 4. Registrar Trabalhos dos Alunos
- Acesse a área de "/Trabalhos".
- Clique em "Novo".
- Preencha os dados do trabalho e associe o aluno e o professor orientador.

### 5. Criar um Convidado para a Banca (Opcional)
- Na página de gerenciamento de convidados em "/MembroExterior", clique em "Novo".
- Preencha os dados do convidado (nome, email, telefone) e associe-o à banca desejada.

### 6. Formar a Banca
- Vá para a seção de "/Banca".
- Clique em "Novo" e adicione os participantes (professores e convidados).
- Relacione o trabalho que será apresentado.

## Funcionalidades Específicas

- **Professores Comentam em Bancas:**
  - Após a formação da banca, professores podem acessar os detalhes da mesma e registrar seus comentários e avaliações.

- **Professores Lecionam Cursos:**
  - Professores podem ser atribuídos aos cursos como responsáveis pelas disciplinas, e isso será exibido tanto nos detalhes dos cursos quanto no perfil do professor.

## Tecnologias Utilizadas

- **Back-end:** ASP.NET Core
- **Front-end:** Razor Pages com Bootstrap para o design responsivo
- **Banco de Dados:** Entity Framework Core com SQLite ou SQL Server
- **Linguagem de Programação:** C#

## Como Executar o Projeto

1. Clone este repositório para sua máquina local:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

2. Navegue até a pasta do projeto e restaure as dependências:
   ```bash
   cd nome-do-projeto
   dotnet restore
   ```

3. Execute as migrações para configurar o banco de dados:
   ```bash
   dotnet ef database update
   ```

4. Inicie o servidor:
   ```bash
   dotnet run
   ```

5. Acesse o sistema no navegador através de `https://localhost:5001`.

---

Este sistema foi desenvolvido com foco em simplicidade e organização, visando atender as principais necessidades de gestão de TCC de forma eficiente. Sinta-se à vontade para contribuir ou sugerir melhorias!

