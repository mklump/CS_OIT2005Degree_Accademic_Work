using System;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace EncryptionExtension {
	[AttributeUsage( AttributeTargets.Method )]
	public class EncryptionAttribute : SoapExtensionAttribute {
		private int priority;

		public override int Priority {
			get { return priority; }
			set { priority = value; }
		}

		public override Type ExtensionType {
			get { return typeof( EncExtension ); }
		}
	}
}
