<?xml version = "1.0"?>

<!-- Fig. D.10 : usage.xsl                        -->
<!-- Transformation of book information into XHTML -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "/">
      <html>
         <xsl:apply-templates/>
      </html>
   </xsl:template>
   
   <xsl:template match = "book">
      <head>
         <title>ISBN <xsl:value-of select = "@isbn" /> - 
            <xsl:value-of select = "title" /></title>
      </head>

      <body>
         <h1><xsl:value-of select = "title" /></h1>

         <h2>by <xsl:value-of select = "author/lastName" />,
            <xsl:value-of select = "author/firstName" /></h2>

         <table border = "1">
            <xsl:for-each select = "chapters/preface">
               <xsl:sort select = "@num" order = "ascending" />
               <tr>
                  <td align = "right">
                     Preface <xsl:value-of select = "@num" />
                  </td>

                  <td>
                     <xsl:value-of select = "." /> (
                     <xsl:value-of select = "@pages" /> pages )
                  </td>
               </tr>
            </xsl:for-each>

            <xsl:for-each select = "chapters/chapter">
               <xsl:sort select = "@num" order = "ascending" />
               <tr>
                  <td align = "right">
                     Chapter <xsl:value-of select = "@num" />
                  </td>

                  <td>
                     <xsl:value-of select = "." /> (
                     <xsl:value-of select = "@pages" /> pages )
                  </td>
               </tr>
            </xsl:for-each>

            <xsl:for-each select = "chapters/appendix">
               <xsl:sort select = "@num" order = "ascending" />
               <tr>
                  <td align = "right">
                     Appendix <xsl:value-of select = "@num"/>
                  </td>

                  <td>
                     <xsl:value-of select = "."/> (
                     <xsl:value-of select = "@pages"/> pages )
                  </td>
               </tr>
            </xsl:for-each>
         </table>
      </body>
   </xsl:template>

</xsl:stylesheet>
