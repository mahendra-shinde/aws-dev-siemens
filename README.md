# aws-dev-siemens
AWS for Siemens


> For Java Developer only !

To set the alternate maven repository from `RedHat` instead of Maven Central
Use following code snippet in `pom.xml`

```xml
<project>
    <repositories>
        <repository>
            <id>aws-repo</id>
            <url>https://maven.repository.redhat.com/ga/</url>
        </repository>
    </repositories>
    <dependencies>
     	<dependency>
         	<groupId>software.amazon.awssdk</groupId>
    		<artifactId>sqs</artifactId>
	    	<version>2.24.0.redhat-00001</version>
        </dependency>

    </dependencies>
</project>
```
