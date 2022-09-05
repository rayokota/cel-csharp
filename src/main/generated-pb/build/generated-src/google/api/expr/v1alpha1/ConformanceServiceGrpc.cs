// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/expr/v1alpha1/conformance_service.proto
// </auto-generated>
// Original file comments:
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Google.Api.Expr.V1Alpha1 {
  /// <summary>
  /// Access a CEL implementation from another process or machine.
  /// A CEL implementation is decomposed as a parser, a static checker,
  /// and an evaluator.  Every CEL implementation is expected to provide
  /// a server for this API.  The API will be used for conformance testing
  /// and other utilities.
  /// </summary>
  public static partial class ConformanceService
  {
    static readonly string __ServiceName = "google.api.expr.v1alpha1.ConformanceService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Api.Expr.V1Alpha1.ParseRequest> __Marshaller_google_api_expr_v1alpha1_ParseRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Api.Expr.V1Alpha1.ParseRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Api.Expr.V1Alpha1.ParseResponse> __Marshaller_google_api_expr_v1alpha1_ParseResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Api.Expr.V1Alpha1.ParseResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Api.Expr.V1Alpha1.CheckRequest> __Marshaller_google_api_expr_v1alpha1_CheckRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Api.Expr.V1Alpha1.CheckRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Api.Expr.V1Alpha1.CheckResponse> __Marshaller_google_api_expr_v1alpha1_CheckResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Api.Expr.V1Alpha1.CheckResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Api.Expr.V1Alpha1.EvalRequest> __Marshaller_google_api_expr_v1alpha1_EvalRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Api.Expr.V1Alpha1.EvalRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Api.Expr.V1Alpha1.EvalResponse> __Marshaller_google_api_expr_v1alpha1_EvalResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Api.Expr.V1Alpha1.EvalResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Api.Expr.V1Alpha1.ParseRequest, global::Google.Api.Expr.V1Alpha1.ParseResponse> __Method_Parse = new grpc::Method<global::Google.Api.Expr.V1Alpha1.ParseRequest, global::Google.Api.Expr.V1Alpha1.ParseResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Parse",
        __Marshaller_google_api_expr_v1alpha1_ParseRequest,
        __Marshaller_google_api_expr_v1alpha1_ParseResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Api.Expr.V1Alpha1.CheckRequest, global::Google.Api.Expr.V1Alpha1.CheckResponse> __Method_Check = new grpc::Method<global::Google.Api.Expr.V1Alpha1.CheckRequest, global::Google.Api.Expr.V1Alpha1.CheckResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Check",
        __Marshaller_google_api_expr_v1alpha1_CheckRequest,
        __Marshaller_google_api_expr_v1alpha1_CheckResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Api.Expr.V1Alpha1.EvalRequest, global::Google.Api.Expr.V1Alpha1.EvalResponse> __Method_Eval = new grpc::Method<global::Google.Api.Expr.V1Alpha1.EvalRequest, global::Google.Api.Expr.V1Alpha1.EvalResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Eval",
        __Marshaller_google_api_expr_v1alpha1_EvalRequest,
        __Marshaller_google_api_expr_v1alpha1_EvalResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Google.Api.Expr.V1Alpha1.ConformanceServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ConformanceService</summary>
    [grpc::BindServiceMethod(typeof(ConformanceService), "BindService")]
    public abstract partial class ConformanceServiceBase
    {
      /// <summary>
      /// Transforms CEL source text into a parsed representation.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Api.Expr.V1Alpha1.ParseResponse> Parse(global::Google.Api.Expr.V1Alpha1.ParseRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Runs static checks on a parsed CEL representation and return
      /// an annotated representation, or a set of issues.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Api.Expr.V1Alpha1.CheckResponse> Check(global::Google.Api.Expr.V1Alpha1.CheckRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Evaluates a parsed or annotation CEL representation given
      /// values of external bindings.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Api.Expr.V1Alpha1.EvalResponse> Eval(global::Google.Api.Expr.V1Alpha1.EvalRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ConformanceService</summary>
    public partial class ConformanceServiceClient : grpc::ClientBase<ConformanceServiceClient>
    {
      /// <summary>Creates a new client for ConformanceService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ConformanceServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ConformanceService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ConformanceServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ConformanceServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ConformanceServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Transforms CEL source text into a parsed representation.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Api.Expr.V1Alpha1.ParseResponse Parse(global::Google.Api.Expr.V1Alpha1.ParseRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Parse(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Transforms CEL source text into a parsed representation.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Api.Expr.V1Alpha1.ParseResponse Parse(global::Google.Api.Expr.V1Alpha1.ParseRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Parse, null, options, request);
      }
      /// <summary>
      /// Transforms CEL source text into a parsed representation.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Expr.V1Alpha1.ParseResponse> ParseAsync(global::Google.Api.Expr.V1Alpha1.ParseRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ParseAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Transforms CEL source text into a parsed representation.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Expr.V1Alpha1.ParseResponse> ParseAsync(global::Google.Api.Expr.V1Alpha1.ParseRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Parse, null, options, request);
      }
      /// <summary>
      /// Runs static checks on a parsed CEL representation and return
      /// an annotated representation, or a set of issues.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Api.Expr.V1Alpha1.CheckResponse Check(global::Google.Api.Expr.V1Alpha1.CheckRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Check(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Runs static checks on a parsed CEL representation and return
      /// an annotated representation, or a set of issues.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Api.Expr.V1Alpha1.CheckResponse Check(global::Google.Api.Expr.V1Alpha1.CheckRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Check, null, options, request);
      }
      /// <summary>
      /// Runs static checks on a parsed CEL representation and return
      /// an annotated representation, or a set of issues.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Expr.V1Alpha1.CheckResponse> CheckAsync(global::Google.Api.Expr.V1Alpha1.CheckRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Runs static checks on a parsed CEL representation and return
      /// an annotated representation, or a set of issues.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Expr.V1Alpha1.CheckResponse> CheckAsync(global::Google.Api.Expr.V1Alpha1.CheckRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Check, null, options, request);
      }
      /// <summary>
      /// Evaluates a parsed or annotation CEL representation given
      /// values of external bindings.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Api.Expr.V1Alpha1.EvalResponse Eval(global::Google.Api.Expr.V1Alpha1.EvalRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Eval(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Evaluates a parsed or annotation CEL representation given
      /// values of external bindings.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Api.Expr.V1Alpha1.EvalResponse Eval(global::Google.Api.Expr.V1Alpha1.EvalRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Eval, null, options, request);
      }
      /// <summary>
      /// Evaluates a parsed or annotation CEL representation given
      /// values of external bindings.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Expr.V1Alpha1.EvalResponse> EvalAsync(global::Google.Api.Expr.V1Alpha1.EvalRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EvalAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Evaluates a parsed or annotation CEL representation given
      /// values of external bindings.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Expr.V1Alpha1.EvalResponse> EvalAsync(global::Google.Api.Expr.V1Alpha1.EvalRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Eval, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ConformanceServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ConformanceServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ConformanceServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Parse, serviceImpl.Parse)
          .AddMethod(__Method_Check, serviceImpl.Check)
          .AddMethod(__Method_Eval, serviceImpl.Eval).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ConformanceServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Parse, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Api.Expr.V1Alpha1.ParseRequest, global::Google.Api.Expr.V1Alpha1.ParseResponse>(serviceImpl.Parse));
      serviceBinder.AddMethod(__Method_Check, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Api.Expr.V1Alpha1.CheckRequest, global::Google.Api.Expr.V1Alpha1.CheckResponse>(serviceImpl.Check));
      serviceBinder.AddMethod(__Method_Eval, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Api.Expr.V1Alpha1.EvalRequest, global::Google.Api.Expr.V1Alpha1.EvalResponse>(serviceImpl.Eval));
    }

  }
}
#endregion