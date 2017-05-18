//
//  MDPConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPConfigurationModel.h"


#pragma mark - Interface
@interface MDPConfigurationModel : _MDPConfigurationModel

+ (NSArray *)configurationWithIdClient:(NSString *)idClient setting:(NSString *)setting managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsConfigurationWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
