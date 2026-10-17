# Tema 1 · PrintDocument + PrintPreviewDialog

Reporte impreso de un listado de alumnos leído desde MariaDB, con logo, encabezado, tabla, pie de página y paginación automática. Usa solo lo que trae .NET (`System.Drawing.Printing`).

📘 **Guía paso a paso:** abre [`guia/Guia-01-PrintDocument.html`](guia/Guia-01-PrintDocument.html) en el navegador.

## Contenido

| Carpeta / archivo | Descripción |
|---|---|
| `bd/reportes_pae.sql` | Crea la base `reportes_pae` y la tabla `alumnos` con 60 registros |
| `src/ReporteImpresion.slnx` | Solución de Visual Studio 2026 |
| `src/ReporteImpresion/` | Proyecto de referencia (VB.NET, .NET 10) |
| `src/ReporteImpresion/Recursos/logo-uni.png` | Logo del encabezado del reporte |

## Ejecutar la solución de referencia

1. Ejecuta `bd/reportes_pae.sql` en MariaDB.
2. Abre `src/ReporteImpresion.slnx` en Visual Studio 2026.
3. En `ConexionBD.vb` ajusta `Uid` y `Pwd`.
4. Ejecuta con **F5** → *Cargar datos* → *Vista previa*.

Sin impresora física, elige **Microsoft Print to PDF** en el cuadro *Imprimir*.

## Entrega de la tarea

Trabaja en una rama de tu equipo y sube tu proyecto en:

```
01-PrintDocument/entregas/<nombre-del-equipo>/
```
