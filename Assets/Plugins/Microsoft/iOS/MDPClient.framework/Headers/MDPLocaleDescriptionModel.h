//
//  MDPLocaleDescriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLocaleDescriptionModel.h"


#pragma mark - Interface
@interface MDPLocaleDescriptionModel : _MDPLocaleDescriptionModel

+ (instancetype)insertIfNotExistsLocaleDescriptionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSString *)localizedDescriptionInSet:(NSSet *)localizedDescriptionsModels language:(NSString *)language;

@end
