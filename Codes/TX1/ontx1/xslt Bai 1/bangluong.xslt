<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="DS">
		<html>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG</h1>
				<xsl:for-each select="congty">
				<div border="1">
					<h4>Tên công ty: <xsl:value-of select="@TenCT"/></h4>
					<xsl:for-each select="donvi">	
						<h4>Tên phòng: <xsl:value-of select="tendv"/></h4>
						<table border="1" style="border-collapse:collapse">
							<tr>
								<th>STT</th>
								<th>Họ tên</th>
								<th>Ngày sinh</th>
								<th>Ngày công</th>
								<th>Lương</th>
							</tr>
							
							<xsl:for-each select="nhanvien">
								<tr>
									<td>
										<xsl:value-of select="position()"/>
									</td>
									<td>
										<xsl:value-of select="hoten"/>
									</td>
									<td>
										<xsl:value-of select="ngaysinh"/>
									</td>
									<td>
										<xsl:value-of select="ngaycong"/>
									</td>
									<td>
										<xsl:if test="ngaycong &lt;=20">
											<xsl:value-of select="ngaycong*150000"/>
										</xsl:if>
										<xsl:if test="ngaycong &gt;20 and ngaycong &lt;=25">
											<xsl:value-of select="(ngaycong - 20)*200000 + 20*150000"/>
										</xsl:if>
										<xsl:if test="ngaycong &gt;25">
											<xsl:value-of select="(ngaycong - 25)*250000 + 20*150000 + 5*200000"/>
										</xsl:if>
									</td>
								</tr>

							</xsl:for-each>
							
						</table>
					</xsl:for-each>
				</div>
				</xsl:for-each>
			</body>
		</html>
		<style>
			table{
				background-color: red;
				text-align: right;
			}
		</style>
    </xsl:template>
</xsl:stylesheet>
