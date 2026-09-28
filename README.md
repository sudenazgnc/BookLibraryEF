
## Run with Docker

### 1. Clone the repository

```bash
git clone https://github.com/sudenazgnc/BookLibraryEF.git
cd BookLibraryEF/BookLibraryEF
```

> The `compose.yml` file is inside the inner `BookLibraryEF` folder, so all Docker commands must be run from there.

### 2. Create the environment file

Copy `.env.example` (located in the repository root) into the current folder as `.env` and set a strong SQL Server SA password.

```bash
cp ../.env.example .env
```

On Windows PowerShell:

```powershell
Copy-Item ..\.env.example .env
```

> `.env` is ignored by Git and should not be committed.

### 3. Start the application

```bash
docker compose up --build
```

Open `http://localhost:5000`.

### 4. Stop the application

```bash
docker compose down
```
