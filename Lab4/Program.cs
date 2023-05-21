using Lab4;
using Lab4.Common;

DataProcessingConfigurationParser configurationParser = new DataProcessingConfigurationParser("DataProcessingConfiguration.json");

DataProcessor dataProcessor = new DataProcessor(
    configurationParser.GetInputStrategy(),
    configurationParser.GetOutputStrategy());

await dataProcessor.Process<FilmModel>();
