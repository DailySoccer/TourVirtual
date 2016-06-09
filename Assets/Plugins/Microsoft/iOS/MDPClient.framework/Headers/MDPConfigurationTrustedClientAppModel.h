//
//  MDPConfigurationTrustedClientAppModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPConfigurationTrustedClientAppModel.h"


#pragma mark - Interface
@interface MDPConfigurationTrustedClientAppModel : _MDPConfigurationTrustedClientAppModel

+ (MDPConfigurationTrustedClientAppModel *)configurationTrustedClientAppWithIdClient:(NSString *)idClient managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsConfigurationTrustedClientAppModelWithIdClient:(NSString *)idClient
                                                               trustedClientApp:(NSString *)trustedClientApp
                                                           managedObjectContext:(NSManagedObjectContext *)context;

@end
