﻿namespace CloudYourself.Backend.Gateways.SelfServicePortalApi.Infrastructure
{
    /// <summary>
    /// Options for app services base urls
    /// </summary>
    public class AppServiceBaseUrlOptions
    {
        /// <summary>
        /// The section name of this options group.
        /// </summary>
        public const string SectionName = "AppServiceBaseUrls";

        /// <summary>
        /// Gets or sets the master data app service url.
        /// </summary>
        /// <value>
        /// The master data url.
        /// </value>
        public string MasterData { get; set; }

        /// <summary>
        /// Gets or sets the billing app service url.
        /// </summary>
        /// <value>
        /// The billing url.
        /// </value>
        public string Billing { get; set;  }

        /// <summary>
        /// Gets or sets the azure app service url.
        /// </summary>
        /// <value>
        /// The azure url.
        /// </value>
        public string Azure { get; set; }

        /// <summary>
        /// Gets or sets the aws.
        /// </summary>
        /// <value>
        /// The aws.
        /// </value>
        public string Aws { get; set; }
    }
}
