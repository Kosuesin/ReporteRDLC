# Tema 2 · ReportViewer Core + RDLC

Reporte de alumnos diseñado en un archivo `.rdlc` y mostrado con el control `ReportViewer` (paquete `ReportViewerCore.WinForms`): agrupado por carrera, con subtotales, total general, filtro por parámetro y exportación a PDF, Excel y Word.

📘 **Guía paso a paso:** abre [`guia/Guia-02-ReportViewer-RDLC.html`](guia/Guia-02-ReportViewer-RDLC.html) en el navegador.

## Contenido

| Carpeta / archivo | Descripción |
|---|---|
| `src/ReporteRDLC.slnx` | Solución de Visual Studio 2026 |
| `src/ReporteRDLC/` | Proyecto de referencia (VB.NET, .NET 10) |
| `src/ReporteRDLC/Reportes/RptAlumnos.rdlc` | Diseño del reporte (con el logo UNI incrustado) |
| `src/ReporteRDLC/Reportes/DsReportes.xsd` | Esquema de campos para el diseñador de informes |

La base de datos es la del tema 1: [`01-PrintDocument/bd/reportes_pae.sql`](../01-PrintDocument/bd/reportes_pae.sql).

## Requisitos

- Visual Studio 2026 con la extensión **Microsoft RDLC Report Designer 2022+** (versión 18), solo para editar el `.rdlc`.
- Paquetes NuGet: `MySqlConnector` 2.4.0 y `ReportViewerCore.WinForms` 15.1.33 (se restauran al compilar).

## Ejecutar la solución de referencia

1. Ejecuta el script SQL del tema 1 en MariaDB (si aún no lo hiciste).
2. Abre `src/ReporteRDLC.slnx`.
3. En `ConexionBD.vb` ajusta `Uid` y `Pwd`.
4. Ejecuta con **F5** → *Generar reporte*.

> ReportViewer Core no se puede publicar como un único `.exe` (*single-file*); publica la aplicación como carpeta.

## Entrega de la tarea

Trabaja en una rama de tu equipo y sube tu proyecto en:

```
02-ReportViewer-RDLC/entregas/<nombre-del-equipo>/
```
