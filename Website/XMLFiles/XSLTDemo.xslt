<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="Students">
        <Students>
            <xsl:apply-templates select="Student"/>
        </Students>
    </xsl:template>
  <xsl:template match="Student">
    <Student>
      <xsl:attribute name="StudentID">
        <xsl:value-of select="StudentID"/>
      </xsl:attribute>
      <xsl:attribute name="FistName">
        <xsl:value-of select="FirstName"/>
      </xsl:attribute>
      <xsl:attribute name="LastName">
        <xsl:value-of select="LastName"/>
      </xsl:attribute>
      <xsl:attribute name="Average">
        <xsl:value-of select="Average"/>
      </xsl:attribute>
    </Student>
  </xsl:template>
</xsl:stylesheet>
