/*
 * Generated from AppInsightsTypes.bond (https://github.com/Microsoft/bond)
*/
package com.microsoft.applicationinsights.contracts;
import java.io.IOException;
import java.io.Writer;
import java.util.Map;
import java.util.LinkedHashMap;

import com.microsoft.telemetry.JsonHelper;

/**
 * Data contract class RequestData.
 */
public class RequestData extends TelemetryData
{
    /**
     * Backing field for property Ver.
     */
    private int ver = 2;
    
    /**
     * Backing field for property Id.
     */
    private String id;
    
    /**
     * Backing field for property Name.
     */
    private String name;
    
    /**
     * Backing field for property StartTime.
     */
    private String startTime;
    
    /**
     * Backing field for property Duration.
     */
    private String duration;
    
    /**
     * Backing field for property ResponseCode.
     */
    private String responseCode;
    
    /**
     * Backing field for property Success.
     */
    private boolean success;
    
    /**
     * Backing field for property HttpMethod.
     */
    private String httpMethod;
    
    /**
     * Backing field for property Url.
     */
    private String url;
    
    /**
     * Backing field for property Properties.
     */
    private Map<String, String> properties;
    
    /**
     * Backing field for property Measurements.
     */
    private Map<String, Double> measurements;
    
    /**
     * Initializes a new instance of the RequestData class.
     */
    public RequestData()
    {
        this.InitializeFields();
        this.SetupAttributes();
    }

    /**
     * Envelope Name for this telemetry.
     */
    public String getEnvelopeName() {
        return "Microsoft.ApplicationInsights.Request";
    }

    /**
     * Base Type for this telemetry.
     */
    public String getBaseType() {
        return "Microsoft.ApplicationInsights.RequestData";
    }

    /**
     * Gets the Ver property.
     */
    public int getVer() {
        return this.ver;
    }
    
    /**
     * Sets the Ver property.
     */
    public void setVer(int value) {
        this.ver = value;
    }
    
    /**
     * Gets the Id property.
     */
    public String getId() {
        return this.id;
    }
    
    /**
     * Sets the Id property.
     */
    public void setId(String value) {
        this.id = value;
    }
    
    /**
     * Gets the Name property.
     */
    public String getName() {
        return this.name;
    }
    
    /**
     * Sets the Name property.
     */
    public void setName(String value) {
        this.name = value;
    }
    
    /**
     * Gets the StartTime property.
     */
    public String getStartTime() {
        return this.startTime;
    }
    
    /**
     * Sets the StartTime property.
     */
    public void setStartTime(String value) {
        this.startTime = value;
    }
    
    /**
     * Gets the Duration property.
     */
    public String getDuration() {
        return this.duration;
    }
    
    /**
     * Sets the Duration property.
     */
    public void setDuration(String value) {
        this.duration = value;
    }
    
    /**
     * Gets the ResponseCode property.
     */
    public String getResponseCode() {
        return this.responseCode;
    }
    
    /**
     * Sets the ResponseCode property.
     */
    public void setResponseCode(String value) {
        this.responseCode = value;
    }
    
    /**
     * Gets the Success property.
     */
    public boolean getSuccess() {
        return this.success;
    }
    
    /**
     * Sets the Success property.
     */
    public void setSuccess(boolean value) {
        this.success = value;
    }
    
    /**
     * Gets the HttpMethod property.
     */
    public String getHttpMethod() {
        return this.httpMethod;
    }
    
    /**
     * Sets the HttpMethod property.
     */
    public void setHttpMethod(String value) {
        this.httpMethod = value;
    }
    
    /**
     * Gets the Url property.
     */
    public String getUrl() {
        return this.url;
    }
    
    /**
     * Sets the Url property.
     */
    public void setUrl(String value) {
        this.url = value;
    }
    
    /**
     * Gets the Properties property.
     */
    public Map<String, String> getProperties() {
        if (this.properties == null) {
            this.properties = new LinkedHashMap<String, String>();
        }
        return this.properties;
    }
    
    /**
     * Sets the Properties property.
     */
    public void setProperties(Map<String, String> value) {
        this.properties = value;
    }
    
    /**
     * Gets the Measurements property.
     */
    public Map<String, Double> getMeasurements() {
        if (this.measurements == null) {
            this.measurements = new LinkedHashMap<String, Double>();
        }
        return this.measurements;
    }
    
    /**
     * Sets the Measurements property.
     */
    public void setMeasurements(Map<String, Double> value) {
        this.measurements = value;
    }
    

    /**
     * Serializes the beginning of this object to the passed in writer.
     * @param writer The writer to serialize this object to.
     */
    protected String serializeContent(Writer writer) throws IOException
    {
        String prefix = super.serializeContent(writer);
        writer.write(prefix + "\"ver\":");
        writer.write(JsonHelper.convert(this.ver));
        prefix = ",";
        
        writer.write(prefix + "\"id\":");
        writer.write(JsonHelper.convert(this.id));
        prefix = ",";
        
        if (!(this.name == null))
        {
            writer.write(prefix + "\"name\":");
            writer.write(JsonHelper.convert(this.name));
            prefix = ",";
        }
        
        writer.write(prefix + "\"startTime\":");
        writer.write(JsonHelper.convert(this.startTime));
        prefix = ",";
        
        writer.write(prefix + "\"duration\":");
        writer.write(JsonHelper.convert(this.duration));
        prefix = ",";
        
        writer.write(prefix + "\"responseCode\":");
        writer.write(JsonHelper.convert(this.responseCode));
        prefix = ",";
        
        writer.write(prefix + "\"success\":");
        writer.write(JsonHelper.convert(this.success));
        prefix = ",";
        
        if (!(this.httpMethod == null))
        {
            writer.write(prefix + "\"httpMethod\":");
            writer.write(JsonHelper.convert(this.httpMethod));
            prefix = ",";
        }
        
        if (!(this.url == null))
        {
            writer.write(prefix + "\"url\":");
            writer.write(JsonHelper.convert(this.url));
            prefix = ",";
        }
        
        if (!(this.properties == null))
        {
            writer.write(prefix + "\"properties\":");
            JsonHelper.writeDictionary(writer, this.properties);
            prefix = ",";
        }
        
        if (!(this.measurements == null))
        {
            writer.write(prefix + "\"measurements\":");
            JsonHelper.writeDictionary(writer, this.measurements);
            prefix = ",";
        }
        
        return prefix;
    }
    
    /**
     * Sets up the events attributes
     */
    public void SetupAttributes()
    {
    }
    
    /**
     * Optionally initializes fields for the current context.
     */
    protected void InitializeFields() {
        QualifiedName = "com.microsoft.applicationinsights.contracts.RequestData";
    }
}
