//
//  MDPAppConfigurationVersionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAppConfigurationVersionModel.h"


#pragma mark - Interface
@interface MDPAppConfigurationVersionModel : _MDPAppConfigurationVersionModel

+ (MDPAppConfigurationVersionModel *)appConfigurationVersionModelWithIdClient:(NSString *)idClient
                                                         managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary
                            idClient:(NSString *)idClient
                managedObjectContext:(NSManagedObjectContext *)context;

@end
