## 🔐 Admin User Configuration (Seed)

The application automatically creates an **Admin** user upon startup if one does not already exist in the database. Credentials are read directly from configuration settings and must never be hardcoded into the source code.

### Local Development (User Secrets)

For local development, set the admin email and password using `dotnet user-secrets`:

```bash
dotnet user-secrets set "AdminUser:Email" "email@admin"
dotnet user-secrets set "AdminUser:Password" "password"
```

### Production / Staging (Environment Variables)

For staging or production environments (Docker, Cloud VPS, etc.), set the following environment variables using standard .NET syntax (\_\_ for nested properties):

```
AdminUser__Email=email@admin
AdminUser__Password=password
```
