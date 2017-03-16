//
//  _MDPCompactExternalIdentityModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCompactExternalIdentityModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCompactExternalIdentityModelAttributes {
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *identityAlias;
	__unsafe_unretained NSString *identityProvider;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPCompactExternalIdentityModelAttributes;

@interface _MDPCompactExternalIdentityModel : NSManagedObject

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* identityAlias;

//- (BOOL)validateIdentityAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* identityProvider;

@property (atomic) int16_t identityProviderValue;
- (int16_t)identityProviderValue;
- (void)setIdentityProviderValue:(int16_t)value_;

//- (BOOL)validateIdentityProvider:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCompactExternalIdentityModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveIdentityAlias;
- (void)setPrimitiveIdentityAlias:(NSString*)value;

- (NSNumber*)primitiveIdentityProvider;
- (void)setPrimitiveIdentityProvider:(NSNumber*)value;

- (int16_t)primitiveIdentityProviderValue;
- (void)setPrimitiveIdentityProviderValue:(int16_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

@end
