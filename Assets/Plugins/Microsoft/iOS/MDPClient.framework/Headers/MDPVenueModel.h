//
//  MDPVenueModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPVenueModel.h"


#pragma mark - Interface
@interface MDPVenueModel : _MDPVenueModel

+ (instancetype)insertIfNotExistsVenueWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
