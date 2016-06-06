//
//  _MDPExternalIdentityModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPExternalIdentityModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPExternalIdentityModelAttributes {
	__unsafe_unretained NSString *identityAlias;
	__unsafe_unretained NSString *identityId;
	__unsafe_unretained NSString *identityProvider;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPExternalIdentityModelAttributes;

@interface _MDPExternalIdentityModel : NSManagedObject

@property (nonatomic, strong) NSString* identityAlias;

//- (BOOL)validateIdentityAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* identityId;

//- (BOOL)validateIdentityId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* identityProvider;

@property (atomic) uint16_t identityProviderValue;
- (uint16_t)identityProviderValue;
- (void)setIdentityProviderValue:(uint16_t)value_;

//- (BOOL)validateIdentityProvider:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPExternalIdentityModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdentityAlias;
- (void)setPrimitiveIdentityAlias:(NSString*)value;

- (NSString*)primitiveIdentityId;
- (void)setPrimitiveIdentityId:(NSString*)value;

- (NSNumber*)primitiveIdentityProvider;
- (void)setPrimitiveIdentityProvider:(NSNumber*)value;

- (uint16_t)primitiveIdentityProviderValue;
- (void)setPrimitiveIdentityProviderValue:(uint16_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

@end
