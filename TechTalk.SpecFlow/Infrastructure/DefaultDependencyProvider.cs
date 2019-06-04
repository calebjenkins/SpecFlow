﻿using BoDi;
using TechTalk.SpecFlow.BindingSkeletons;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Discovery;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.CucumberMessages;
using TechTalk.SpecFlow.CucumberMessages.Sinks;
using TechTalk.SpecFlow.EnvironmentAccess;
using TechTalk.SpecFlow.ErrorHandling;
using TechTalk.SpecFlow.FileAccess;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.TestFramework;
using TechTalk.SpecFlow.Time;
using TechTalk.SpecFlow.Tracing;

namespace TechTalk.SpecFlow.Infrastructure
{
    //NOTE: Please update https://github.com/techtalk/SpecFlow/wiki/Available-Containers-&-Registrations if you change registration defaults

    public partial class DefaultDependencyProvider : IDefaultDependencyProvider
    {
        partial void RegisterUnitTestProviders(ObjectContainer container);

        public virtual void RegisterGlobalContainerDefaults(ObjectContainer container)
        {
            container.RegisterTypeAs<DefaultRuntimeConfigurationProvider, IRuntimeConfigurationProvider>();

            container.RegisterTypeAs<TestRunnerManager, ITestRunnerManager>();

            container.RegisterTypeAs<StepFormatter, IStepFormatter>();
            container.RegisterTypeAs<TestTracer, ITestTracer>();

            container.RegisterTypeAs<DefaultListener, ITraceListener>();
            container.RegisterTypeAs<TraceListenerQueue, ITraceListenerQueue>(); 

            container.RegisterTypeAs<ErrorProvider, IErrorProvider>();
            container.RegisterTypeAs<RuntimeBindingSourceProcessor, IRuntimeBindingSourceProcessor>();
            container.RegisterTypeAs<RuntimeBindingRegistryBuilder, IRuntimeBindingRegistryBuilder>();
            container.RegisterTypeAs<BindingRegistry, IBindingRegistry>();
            container.RegisterTypeAs<BindingFactory, IBindingFactory>();
            container.RegisterTypeAs<StepDefinitionRegexCalculator, IStepDefinitionRegexCalculator>();
            container.RegisterTypeAs<BindingInvoker, IBindingInvoker>();
            container.RegisterTypeAs<SynchronousBindingDelegateInvoker, ISynchronousBindingDelegateInvoker>();
            container.RegisterTypeAs<TestObjectResolver, ITestObjectResolver>();

            container.RegisterTypeAs<StepDefinitionSkeletonProvider, IStepDefinitionSkeletonProvider>();
            container.RegisterTypeAs<DefaultSkeletonTemplateProvider, ISkeletonTemplateProvider>();
            container.RegisterTypeAs<StepTextAnalyzer, IStepTextAnalyzer>();

            container.RegisterTypeAs<RuntimePluginLoader, IRuntimePluginLoader>();
            container.RegisterTypeAs<RuntimePluginLocator, IRuntimePluginLocator>();
            container.RegisterTypeAs<RuntimePluginLocationMerger, IRuntimePluginLocationMerger>();

            container.RegisterTypeAs<BindingAssemblyLoader, IBindingAssemblyLoader>();

            container.RegisterTypeAs<ConfigurationLoader, IConfigurationLoader>();

            container.RegisterTypeAs<ObsoleteStepHandler, IObsoleteStepHandler>();

            container.RegisterTypeAs<EnvironmentWrapper, IEnvironmentWrapper>();
            container.RegisterTypeAs<BinaryFileAccessor, IBinaryFileAccessor>();
            container.RegisterTypeAs<ProtobufFileSinkOutput, IProtobufFileSinkOutput>();
            container.RegisterTypeAs<ProtobufFileNameResolver, IProtobufFileNameResolver>();
            container.RegisterTypeAs<ProtobufFileSink, ICucumberMessageSink>();
            container.RegisterInstanceAs(new ProtobufFileSinkConfiguration("CucumberMessageQueue/messages"));
            container.RegisterTypeAs<DefaultTestRunContext, ITestRunContext>();

            container.RegisterTypeAs<SpecFlowPath, ISpecFlowPath>();

            container.RegisterTypeAs<UtcDateTimeClock, IClock>();
            container.RegisterTypeAs<CucumberMessageFactory, ICucumberMessageFactory>();
            container.RegisterTypeAs<TestResultFactory, ITestResultFactory>();
            container.RegisterTypeAs<CucumberMessageSender, ICucumberMessageSender>();
            container.RegisterTypeAs<PickleIdGenerator, IPickleIdGenerator>();
            container.RegisterTypeAs<PickleIdStore, IPickleIdStore>();
            container.RegisterTypeAs<PickleIdStoreDictionaryFactory, IPickleIdStoreDictionaryFactory>();
            container.RegisterTypeAs<CucumberMessageSenderValueMockSource, ICucumberMessageSenderValueMockSource>();

            RegisterUnitTestProviders(container);
        }

        public virtual void RegisterTestThreadContainerDefaults(ObjectContainer testThreadContainer)
        {
            testThreadContainer.RegisterTypeAs<TestRunner, ITestRunner>();
            testThreadContainer.RegisterTypeAs<ContextManager, IContextManager>();
            testThreadContainer.RegisterTypeAs<TestExecutionEngine, ITestExecutionEngine>();

            // needs to invoke methods so requires the context manager
            testThreadContainer.RegisterTypeAs<StepArgumentTypeConverter, IStepArgumentTypeConverter>();
            testThreadContainer.RegisterTypeAs<StepDefinitionMatchService, IStepDefinitionMatchService>();

            testThreadContainer.RegisterTypeAs<AsyncTraceListener, ITraceListener>();
            testThreadContainer.RegisterTypeAs<TestTracer, ITestTracer>();
        }

        public void RegisterScenarioContainerDefaults(ObjectContainer scenarioContainer)
        {
            scenarioContainer.RegisterTypeAs<SpecFlowOutputHelper, ISpecFlowOutputHelper>();

        }
    }
}