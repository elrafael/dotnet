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

## 🔐 JWT Secret Key

The application uses a symmetric secret key to sign JWTs. Keep this key secret and never commit it to source control.

### Local Development (User Secrets)

For local development, set the JWT secret using `dotnet user-secrets`:

```bash
dotnet user-secrets set "JwtSettings:SecretKey" "a_very_secure_key"
```

Choose a strong random value (recommend 32+ characters). You can generate one with a secure tool like `openssl rand -base64 32` or a password manager.

### Production / Staging (Environment Variables)

In production or staging, expose the secret via environment variables using the double-underscore `__` syntax for nested configuration:

```
JwtSettings__SecretKey=your_production_secret_here
```

When running in containers or cloud platforms, use the platform's secret management features (Docker secrets, AWS Secrets Manager, Azure Key Vault, etc.) rather than plain environment variables when possible.

```bash
dotnet user-secrets set "JwtSettings:SecretKey" "a_very_secure_key"
```
