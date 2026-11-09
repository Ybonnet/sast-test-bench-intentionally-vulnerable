# SAST test bench — intentionally vulnerable

> **Warning: this code is intentionally insecure. Do not deploy it, do not reuse it.**

A small, fictional web application (ASP.NET Core API in C# and a TypeScript / Vue front end) written to compare
static analysis (SAST) tools on the kind of flaws that AI coding assistants commonly produce. It also contains a
few safe counter-examples, to measure false positives.

- Every name, host, key, token and password in this repository is **fictional**. None of them is a real secret
  and none of them grants access to anything.
- The application is not meant to build into a working product, nor to run.
- Issues and pull requests are not monitored.

## Layout

| Folder | Content |
| --- | --- |
| `dotnet/` | ASP.NET Core API (.NET 10, C#) |
| `front/src/` | TypeScript and Vue components |

## License

[MIT](LICENSE).
