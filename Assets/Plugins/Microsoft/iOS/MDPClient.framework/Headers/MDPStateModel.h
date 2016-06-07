//
//  MDPStateModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPStateModel.h"


#pragma mark - Interface
@interface MDPStateModel : _MDPStateModel

+ (NSArray *)statesWithLanguage:(NSString *)language
                    countryCode:(NSString *)countryCode
           managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsStateWithDictionary:(NSDictionary *)dictionary
                                managedObjectContext:(NSManagedObjectContext *)context;

@end
