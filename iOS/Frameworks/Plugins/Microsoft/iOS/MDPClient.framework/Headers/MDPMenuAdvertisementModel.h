//
//  MDPMenuAdvertisementModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMenuAdvertisementModel.h"


#pragma mark - Interface
@interface MDPMenuAdvertisementModel : _MDPMenuAdvertisementModel

+ (instancetype)insertIfNotExistsLocaleDescriptionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
