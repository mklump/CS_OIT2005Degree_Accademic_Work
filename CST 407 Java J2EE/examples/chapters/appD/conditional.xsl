<?xml version = "1.0"?>

<!-- Fig. D.13 : conditional.xsl            -->
<!-- xsl:choose, xsl:when and xsl:otherwise -->

<xsl:stylesheet version = "1.0" 
   xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

   <xsl:template match = "/">
      <html>

         <body>
            Appointments
            <br/>
            <xsl:apply-templates select = "planner/year"/>
         </body>

      </html>
   </xsl:template>
   
   <xsl:template match = "year">
      <strong>Year: </strong>
      <xsl:value-of select = "@value"/>
      <br/>
      <xsl:for-each select = "date/note">
         <xsl:sort select = "../@day" order = "ascending"
            data-type = "number"/>
         <strong>
            Day: 
            <xsl:value-of select = "../@day"/>/
            <xsl:value-of select = "../@month"/>
         </strong>

         <xsl:choose>

            <xsl:when test = 
               "@time &gt; '0500' and @time &lt; '1200'">
               Morning (<xsl:value-of select = "@time"/>):
            </xsl:when>

            <xsl:when test =
               "@time &gt; '1200' and @time &lt; '1700'">
               Afternoon (<xsl:value-of select = "@time"/>):
            </xsl:when>

            <xsl:when test = 
               "@time &gt; '1700' and @time &lt; '2000'">
               Evening (<xsl:value-of select = "@time"/>):
            </xsl:when>

            <xsl:when test = 
               "@time &gt; '2000' and @time &lt; '2400'">
               Night (<xsl:value-of select = "@time"/>):
            </xsl:when>

            <xsl:otherwise>
               Entire day:
            </xsl:otherwise>

         </xsl:choose>

         <xsl:value-of select = "."/>

         <xsl:if test = ". = ''">
            n/a
         </xsl:if>

         <br/>
      </xsl:for-each>

   </xsl:template>

</xsl:stylesheet>
