﻿using System;
using Ninject.Activation;
using Ninject.Activation.Caching;
using Ninject.Activation.Strategies;
using Ninject.Injection;
using Ninject.Injection.Linq;
using Ninject.Modules;
using Ninject.Planning;
using Ninject.Planning.Strategies;
using Ninject.Selection;
using Ninject.Selection.Heuristics;

namespace Ninject
{
	/// <summary>
	/// The standard implementation of a kernel.
	/// </summary>
	public class StandardKernel : KernelBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StandardKernel"/> class.
		/// </summary>
		/// <param name="modules">The modules to load into the kernel.</param>
		public StandardKernel(params IModule[] modules) : base(modules) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="StandardKernel"/> class.
		/// </summary>
		/// <param name="settings">The configuration to use.</param>
		/// <param name="modules">The modules to load into the kernel.</param>
		public StandardKernel(INinjectSettings settings, params IModule[] modules) : base(settings, modules) { }

		/// <summary>
		/// Adds components to the kernel during startup.
		/// </summary>
		protected override void AddComponents()
		{
			Components.Add<IPipeline, Pipeline>();
			Components.Add<IActivationStrategy, PropertyInjectionStrategy>();
			Components.Add<IActivationStrategy, MethodInjectionStrategy>();
			Components.Add<IActivationStrategy, InitializableStrategy>();
			Components.Add<IActivationStrategy, StartableStrategy>();
			Components.Add<IActivationStrategy, BindingActionStrategy>();
			Components.Add<IActivationStrategy, DisposableStrategy>();

			Components.Add<ICache, Cache>();
			Components.Add<ICachePruner, CachePruner>();

			Components.Add<IPlanner, Planner>();
			Components.Add<IPlanningStrategy, ConstructorReflectionStrategy>();
			Components.Add<IPlanningStrategy, PropertyReflectionStrategy>();
			Components.Add<IPlanningStrategy, MethodReflectionStrategy>();

			Components.Add<ISelector, Selector>();
			Components.Add<IConstructorScorer, StandardConstructorScorer>();
			Components.Add<IPropertyInjectionHeuristic, StandardPropertyInjectionHeuristic>();
			Components.Add<IMethodInjectionHeuristic, StandardMethodInjectionHeuristic>();

			Components.Add<IInjectorFactory, InjectorFactory>();
			Components.Add<IModuleLoader, ModuleLoader>();
		}
	}
}