﻿namespace LangChain.Providers.OpenAI;

/// <summary>
/// 
/// </summary>
public class OpenAiConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    public const string SectionName = "OpenAI";

    /// <summary>
    /// Default configuration according to the official API documentation. <br/>
    /// </summary>
    public static OpenAiConfiguration Default { get; } = new()
    {

    };

    /// <inheritdoc cref="IModelWithUniqueUserIdentifier.User"/>
    public string? User { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Endpoint { get; set; }

    /// <summary>
    /// ID of the model to use. <br/>
    /// See the model endpoint compatibility table for details on which models work with the Chat API. <br/>
    /// https://platform.openai.com/docs/models/model-endpoint-compatibility <br/>
    /// </summary>
    public string? ModelId { get; set; }

    /// <summary>
    /// ID of the embedding model to use. <br/>
    /// </summary>
    public string EmbeddingModelId { get; set; } = EmbeddingModelIds.Ada002;

    /// <summary>
    /// ID of the moderation model to use. <br/>
    /// </summary>
    public string ModerationModelId { get; set; } = ModerationModelIds.Latest;

    /// <summary>
    /// What sampling temperature to use, between 0 and 2. <br/>
    /// Higher values like 0.8 will make the output more random,
    /// while lower values like 0.2 will make it more focused and deterministic. <br/>
    /// We generally recommend altering this or <see cref="TopP"/> but not both. <br/>
    /// Defaults to 1. <br/>
    /// </summary>
    public double Temperature { get; set; } = 1.0;

    /// <summary>
    /// The maximum number of tokens to generate in the chat completion. <br/>
    /// The total length of input tokens and generated tokens is limited by the model's context length. <br/>
    /// Defaults to int.MaxValue. <br/>
    /// </summary>
    public int MaxTokens { get; set; } = int.MaxValue;

    /// <summary>
    /// An alternative to sampling with temperature, called nucleus sampling,
    /// where the model considers the results of the tokens with top_p probability mass.
    /// So 0.1 means only the tokens comprising the top 10% probability mass are considered. <br/>
    /// We generally recommend altering this or <see cref="Temperature"/> but not both. <br/>
    /// Defaults to 1. <br/>
    /// </summary>
    public double TopP { get; set; } = 1.0;

    /// <summary>
    /// Number between -2.0 and 2.0. <br/>
    /// Positive values penalize new tokens based on their existing frequency in the text so far,
    /// decreasing the model's likelihood to repeat the same line verbatim. <br/>
    /// Defaults to 0. <br/>
    /// </summary>
    public double FrequencyPenalty { get; set; }

    /// <summary>
    /// Number between -2.0 and 2.0. <br/>
    /// Positive values penalize new tokens based on whether they appear in the text so far,
    /// increasing the model's likelihood to talk about new topics. <br/>
    /// Defaults to 0. <br/>
    /// </summary>
    public double PresencePenalty { get; set; }

    /// <summary>
    /// How many chat completion choices to generate for each input message. <br/>
    /// Defaults to 1. <br/>
    /// </summary>
    public int N { get; set; } = 1;

    /// <summary>
    /// Modify the likelihood of specified tokens appearing in the completion. <br/>
    /// Accepts a json object that maps tokens (specified by their token ID in the tokenizer)
    /// to an associated bias value from -100 to 100.
    /// Mathematically, the bias is added to the logits generated by the model prior to sampling. <br/>
    /// The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection;
    /// values like -100 or 100 should result in a ban or exclusive selection of the relevant token. <br/>
    /// </summary>
    public IReadOnlyDictionary<string, int>? LogitBias { get; set; } = new Dictionary<string, int>();

    /// <summary>
    /// If set, partial message deltas will be sent, like in ChatGPT. <br/>
    /// Tokens will be sent as data-only server-sent events as they become available. <br/>
    /// Enabling disables tokenUsage reporting <br/>
    /// Defaults to false. <br/>
    /// </summary>
    public bool Streaming { get; set; }

    /// <summary>
    /// Up to 4 sequences where the API will stop generating further tokens. <br/>
    /// </summary>
    public IReadOnlyCollection<string> Stop { get; set; } = Array.Empty<string>();
}